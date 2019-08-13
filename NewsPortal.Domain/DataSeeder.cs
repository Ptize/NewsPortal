﻿using NewsPortal.Data;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Domain
{
    public class DataSeeder
    {
        public static void InitData(DataContext context)
        {
            #region News
            List<News> news = new List<News>
            {
                new News(){
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Photo = 0,
                    Headline = "Российский Су-27 оттеснил натовский F-18 от самолета Шойгу",
                    Review = "Российский Су-27 оттеснил истребитель НАТО F-18, который пытался приблизиться к самолету министра обороны Сергея Шойгу, сообщил корреспондент ТАСС, который был на борту самолета. Инцидент произошел над нейтральными водами Балтийского моря.",
                    Text = "Российский Су-27 оттеснил истребитель НАТО F-18, который пытался приблизиться к самолету министра обороны Сергея Шойгу, сообщил корреспондент ТАСС, который был на борту самолета. Инцидент произошел над нейтральными водами Балтийского моря.Речь идет о специальной модификации истребителя F-18 для ВВС Испании — EF-18 — с бортовым номером 12-26. Он с мая находится на дежурстве в районе Балтийского моря, базируется в Литве на авиабазе Шауляй.Самолет министра обороны летел из Калининграда в Москву, где Сергей Шойгу принял участие в церемонии закладки камня под строительство филиала Нахимовского военно-морского училища. Его сопровождали два истребителя морской авиации Балтийского флота.",
                },
                new News(){
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Photo = 0,
                    Headline = "Минтруд предложил обсудить сокращение рабочей недели до четырех дней",
                    Review = "Вице-премьер Татьяна Голикова, в свою очередь, говорила, что при переходе на четырехдневную рабочую неделю остается открытым вопрос зарплаты. Согласно данным опроса ВЦИОМа, почти половина россиян (48%) идею перехода на график с четырьмя рабочими днями в неделю не поддерживают.",
                    Text = "Законодательство не запрещает переход на четырехдневную рабочую неделю, а лишь ограничивает ее максимальный порог до 40 часов, отметили в министерстве.В России на предприятиях уже сейчас можно вводить сокращенную рабочую неделю — например, четырехдневную, — поскольку это никак не противоречит законодательству. Об этом РБК сообщили в пресс-службе Минтруда.В ведомстве отметили, что Трудовой кодекс ограничивает максимальную продолжительность рабочей недели. Она должна длиться не более 40 часов.«При этом нижней границы не существует. Таким образом, в рамках социального партнерства / коллективного договора в организациях уже сегодня может быть уменьшено как количество часов в рабочем дне, так и количество самих рабочих дней», — сказали в Минтруде. Также там добавили, что получили письмо от Федерации независимых профсоюзов, которая выступила за введение четырехдневной рабочей недели. В Минтруде предложили вынести этот вопрос на обсуждение с участием как профсоюзов, так и работодателей — всех сторон социального партнерства. Свою инициативу профсоюзы направили на рассмотрение Российской трехсторонней комиссии по регулированию социально-трудовых отношений. За четырехдневную рабочую неделю ранее высказывался премьер-министр Дмитрий Медведев. По его словам, такой график станет «новой основой социально-трудового контракта». Вице-премьер Татьяна Голикова, в свою очередь, говорила, что при переходе на четырехдневную рабочую неделю остается открытым вопрос зарплаты. Согласно данным опроса ВЦИОМа, почти половина россиян (48%) идею перехода на график с четырьмя рабочими днями в неделю не поддерживают. Прежде всего они боятся потерять в деньгах.",
                },
                new News(){
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Photo = 0,
                    Headline = "Телефонные мошенники изобрели новый способ обмана клиентов банков",
                    Review = "Уже поставлен рекорд незаконного списания с карты - 3,5 млн руб. Телефонные мошенники изобрели новый способ обмана клиентов российских банков, отмечает Российская газета. Согласно новой схеме, грабители сообщают клиенту банка о попытке вывести средства со счета в другом регионе.",
                    Text = "Телефонные мошенники изобрели новый способ обмана клиентов российских банков. Аферисты, представляясь сотрудниками кредитной организации, теперь не просят предоставить личные данные, но сообщают о попытке вывести средства со счета. И предлагают заблокировать незаконную операцию при помощи программы teamviewer. Уже поставлен рекорд незаконного списания с карты — 3,5 млн руб. ",
                },
                new News(){
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Photo = 0,
                    Headline = "Зеленский упростил получение гражданства Украины некоторым россиянам",
                    Review = "Получение гражданства Украины в упрощенном порядке смогут получить россияне, которые преследуются на родине по политическим мотивам. Соответствующее поручение правительству поступило от президента Украины Владимира Зеленского. Указ уже опубликован на сайте главы украинского государства.",
                    Text = "Получение гражданства Украины в упрощенном порядке смогут получить россияне, которые преследуются на родине по политическим мотивам. Соответствующее поручение правительству поступило от президента Украины Владимира Зеленского. Указ уже опубликован на сайте главы украинского государства. По упрощенной процедуре смогут получить украинское гражданство лица, которые проходят службу в Вооруженных силах Украины и которые имеют выдающиеся заслуги перед Украиной, «либо принятие которых в гражданство Украины представляет государственный интерес», отмечается в указе. Президент также поручил кабинету министров обеспечить оптимизацию процесса рассмотрения заявлений граждан РФ о признании беженцем или лицом, нуждающимся в дополнительной защите",
                },
                new News(){
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Photo = 0,
                    Headline = "В «Ахмате» опровергли воздействие на судью после матча со «Спартаком»",
                    Review = "Пресс-служба «Ахмата» прокомментировала видеозапись, на которой президент клуба Магомед Даудов после завершения игры пятого тура чемпионата России со «Спартаком» держит за руку главного арбитра встречи Алексея Сухого.",
                    Text = "В грозненском клубе назвали «нормальным явлением» поведение президента команды Магомеда Даудова, который после окончания матча со «Спартаком» сопроводил в подтрибунное помещение главного арбитра встречи Алексея Сухого. Пресс-служба «Ахмата» прокомментировала видеозапись, на которой президент клуба Магомед Даудов после завершения игры пятого тура чемпионата России со «Спартаком» держит за руку главного арбитра встречи Алексея Сухого. В грозненской команде считают, в данном эпизоде не было воздействия на судью со стороны руководителя. «После окончания матча руководители клубов и главные тренеры часто обсуждают эпизоды игры с судьей, это нормальное явление. После игры «Ахмат» — «Спартак» Магомед Даудов пожал руку Алексею Сухому, они перекинулись несколькими фразами по матчу и отправились в подтрибунное помещение», — приводит «Чемпионат» заявление пресс-службы «Ахмата». В «Ахмате» также подчеркнули, что в том случае, если бы Даудов оказывал некое воздействие на судью, это было бы отражено в итоговом протоколе и рапорте делегата встречи.",
                },
            };
            #endregion

            context.AddRange(news);
            context.SaveChanges();
        }
    }
}
