using Application.DTO.User;
using Application.Exceptions;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Novacode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries;

public class ExportDataCommercialProposalQuery: IRequest<byte[]>
{
    public ExportDataCommercialProposalQuery(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; set; }
}

public class ExportDataCommercialProposalQueryHandler : IRequestHandler<ExportDataCommercialProposalQuery, byte[]>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ExportDataCommercialProposalQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<byte[]> Handle(ExportDataCommercialProposalQuery req, CancellationToken cancellationToken)
    {
        var order = await _uow.OrderRepo.FindIncludingAsync(o => o.Id == req.OrderId, noTrack: true, x => x.User, x => x.Offer, x => x.Offer.DevelopmentTimeline, x => x.Offer.SiteType, x => x.Offer.SiteDesign);
        if (order == null) throw new ApiException("Error! Order not found!");

        var offerId = order.Offer.Id;

        var offerSupports = await _uow.OfferSupportRepo.FindAllIncludingAsync(o => o.OfferId == offerId, noTrack: true, x => x.SiteSupport);
        var listSupports = offerSupports.Select(o => o.SiteSupport).ToList();

        var offerModules = await _uow.OfferModuleRepo.FindAllIncludingAsync(o => o.OfferId == offerId, noTrack: true, x => x.SiteModules);
        var listModules = offerModules.Select(o => o.SiteModules).ToList();
        
        var offerOptional = await _uow.OfferOptionalDesignsRepo.FindAllIncludingAsync(o => o.OfferId == offerId, noTrack: true, x => x.OptionalDesign);
        var listOptional = offerOptional.Select(o => o.OptionalDesign).ToList();
        

        using(MemoryStream mem = new MemoryStream())
        {
            using (var document = DocX.Create(mem))
            {
                // Установка колонтитула для первой страницы
                document.DifferentFirstPage = true;
                document.AddHeaders();

                // Получение колонтитула первой страницы
                Header firstPageHeader = document.Headers.first;

                // Добавление параграфа с текстом в колонтитул первой страницы
                Paragraph headerParagraph = firstPageHeader.InsertParagraph();

                var headerTxt = "ООО «Твинс»\r\n214000, г.Смоленск, ул. Карла Маркса, д. 12\r\nИНН 6731067957/ КПП 673201001\r\nТелефон +7 (4812) 20-94-60, +7 (499) 506-97-20\r\nE-mail: info@web-canape.ru";

                headerParagraph.InsertText(headerTxt);
                headerParagraph.Alignment = Alignment.right;

                var title = document.InsertParagraph();
                title.Alignment = Alignment.center;
                Formatting titleFormat = new Formatting();
                titleFormat.Bold = true;
                titleFormat.Size = 16;
                title.InsertText($"Разработка и продвижение сайтов\r\nс гарантией результата\r\n", false, titleFormat);

                var subTitle = document.InsertParagraph();
                subTitle.Alignment = Alignment.center;
                Formatting subTitleFormat = new Formatting();
                subTitleFormat.Size = 18;
                subTitle.InsertText($"КОММЕРЧЕСКОЕ ПРЕДЛОЖЕНИЕ № {order.Offer.OfferNumber}\r\nот {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} г.", false, subTitleFormat);
                document.InsertParagraph("\r\n");

                var table = this.CreateTable(document, order, listSupports, listModules, listOptional);

                document.InsertTable(table);

                var totalPrice = document.InsertParagraph();
                totalPrice.Alignment = Alignment.left;
                var totalPriceFormat = new Formatting();
                totalPriceFormat.Bold = true;
                totalPriceFormat.Size = 16;

                totalPrice.InsertText($"ИТОГО: {(float)order.OrderCost} руб.", false, totalPriceFormat);

                document.InsertParagraph("\r\n\r\n");

                var footerTxt = document.InsertParagraph();
                footerTxt.Alignment = Alignment.left;
                var footerTxtFormat = new Formatting();
                footerTxtFormat.Size = 12;
                footerTxt.InsertText($"Настоящее предложение действует в течение недели после формирования.\r\nНастоящее предложение не может быть отозвано и является безотзывной офертой.", false, footerTxtFormat);

                document.InsertParagraph("\r\n\r\n");
                document.InsertParagraph($"«___» ________________ {DateTime.Now.Year} г.");

                // End
                document.Save();
            }
            return mem.ToArray();
        }
    }

    private Novacode.Table CreateTable(DocX doc, OrderEntity order, List<SiteSupportEntity> listSuport, List<SiteModulesEntity> listModules, List<OptionalDesignEntity> listOptional)
    {
        Novacode.Table table = doc.AddTable(6, 3);

        foreach (Row row in table.Rows)
        {
            row.Cells[0].Width = 200;
            row.Cells[1].Width = 200;
            row.Cells[2].Width = 200;
        }

        table.AutoFit = AutoFit.Contents;
        table.AutoFit = AutoFit.ColumnWidth;
        //table.Alignment = Alignment.center;

        table.Rows[0].Cells[0].InsertParagraph().Append("Тип сайта").Bold();
        table.Rows[0].Cells[1].InsertParagraph().Append(order.Offer.SiteType.Name);
        table.Rows[0].Cells[2].InsertParagraph().Append(order.Offer.SiteType.Price.ToString() + " руб.");

        table.Rows[1].Cells[0].InsertParagraph().Append("Подключаемые модули").Bold();
        StringBuilder sModTxt = new StringBuilder();
        double modPrice = 0;
        var idx = 1;
        foreach(var item in listModules)
        {
            sModTxt.AppendLine(idx.ToString() + ". " + item.Name.ToLower());
            modPrice += item.Price;
            idx++;
        }
        table.Rows[1].Cells[1].InsertParagraph().Append(sModTxt.ToString());
        table.Rows[1].Cells[2].InsertParagraph().Append(modPrice.ToString() + " руб.");


        table.Rows[2].Cells[0].InsertParagraph().Append("Дизайн").Bold();
        table.Rows[2].Cells[1].InsertParagraph().Append(order.Offer.SiteDesign.Name);
        table.Rows[2].Cells[2].InsertParagraph().Append(order.Offer.SiteDesign.Price.ToString() + " руб.");

        table.Rows[3].Cells[0].InsertParagraph().Append("Дополнительно").Bold();
        StringBuilder sOptTxt = new StringBuilder();
        double optPrice = 0;
        idx = 1;
        foreach (var item in listOptional)
        {
            sOptTxt.AppendLine(idx.ToString() + ". " + item.Name.ToLower());
            optPrice += item.Price;
            idx++;
        }
        table.Rows[3].Cells[1].InsertParagraph().Append(sOptTxt.ToString());
        table.Rows[3].Cells[2].InsertParagraph().Append(optPrice.ToString() + " руб.");

        table.Rows[4].Cells[0].InsertParagraph().Append("Поддержка сайта").Bold();
        StringBuilder sSupTxt = new StringBuilder();
        double supPrice = 0;
        idx = 1;
        foreach (var item in listSuport)
        {
            sSupTxt.AppendLine(idx.ToString() + ". " + item.Name.ToLower());
            supPrice += item.Price;
            idx++;
        }
        table.Rows[4].Cells[1].InsertParagraph().Append(sSupTxt.ToString());
        table.Rows[4].Cells[2].InsertParagraph().Append(supPrice.ToString() + " руб.");

        table.Rows[5].Cells[0].InsertParagraph().Append("Сроки разработки").Bold();
        table.Rows[5].Cells[1].InsertParagraph().Append(order.Offer.DevelopmentTimeline.Name);
        table.Rows[5].Cells[2].InsertParagraph().Append("Коэффициент увеличения цены - " + order.Offer.DevelopmentTimeline.MultiplicationFactor.ToString().Substring(0, 4));


        return table;
    }
}

public class ExportDataCommercialProposalQueryValidator: AbstractValidator<ExportDataCommercialProposalQuery>
{
    private readonly IUnitOfWork _uow;

    public ExportDataCommercialProposalQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.OrderId)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error!: Такого заказа не существует!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OrderRepo.ExistsAsync(id);
    }
}