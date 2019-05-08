using RC.Enumerations;
using RC.Model.Pieces;
using RC.Model.Slots; using RC.Model.Stickers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.Model
{
    public class CubePatternModel
    {
        public CubePatternModel(
            PaternStickerTypes north52, PaternStickerTypes north60, PaternStickerTypes north7,
            PaternStickerTypes north15, PaternStickerTypes north0, PaternStickerTypes north22,
            PaternStickerTypes north30, PaternStickerTypes north37, PaternStickerTypes north45,

            PaternStickerTypes south52, PaternStickerTypes south60, PaternStickerTypes south7,
            PaternStickerTypes south15, PaternStickerTypes south0, PaternStickerTypes south22,
            PaternStickerTypes south30, PaternStickerTypes south37, PaternStickerTypes south45,

            PaternStickerTypes east52, PaternStickerTypes east60, PaternStickerTypes east7,
            PaternStickerTypes east15, PaternStickerTypes east0, PaternStickerTypes east22,
            PaternStickerTypes east30, PaternStickerTypes east37, PaternStickerTypes east45,

            PaternStickerTypes west52, PaternStickerTypes west60, PaternStickerTypes west7,
            PaternStickerTypes west15, PaternStickerTypes west0, PaternStickerTypes west22,
            PaternStickerTypes west30, PaternStickerTypes west37, PaternStickerTypes west45,

            PaternStickerTypes front52, PaternStickerTypes front60, PaternStickerTypes front7,
            PaternStickerTypes front15, PaternStickerTypes front0, PaternStickerTypes front22,
            PaternStickerTypes front30, PaternStickerTypes front37, PaternStickerTypes front45,

            PaternStickerTypes back52, PaternStickerTypes back60, PaternStickerTypes back7,
            PaternStickerTypes back15, PaternStickerTypes back0, PaternStickerTypes back22,
            PaternStickerTypes back30, PaternStickerTypes back37, PaternStickerTypes back45
            )
        {

            this.North52 = north52;
            this.North60 = north60;
            this.North07 = north7;
            this.North15 = north15;
            this.North00 = north0;
            this.North22 = north22;
            this.North30 = north30;
            this.North37 = north37;
            this.North45 = north45;

            this.South52 = south52;
            this.South60 = south60;
            this.South07 = south7;
            this.South15 = south15;
            this.South00 = south0;
            this.South22 = south22;
            this.South30 = south30;
            this.South37 = south37;
            this.South45 = south45;

            this.East52 = east52;
            this.East60 = east60;
            this.East07 = east7;
            this.East15 = east15;
            this.East00 = east0;
            this.East22 = east22;
            this.East30 = east30;
            this.East37 = east37;
            this.East45 = east45;

            this.West52 = west52;
            this.West60 = west60;
            this.West07 = west7;
            this.West15 = west15;
            this.West00 = west0;
            this.West22 = west22;
            this.West30 = west30;
            this.West37 = west37;
            this.West45 = west45;

            this.Front52 = front52;
            this.Front60 = front60;
            this.Front07 = front7;
            this.Front15 = front15;
            this.Front00 = front0;
            this.Front22 = front22;
            this.Front30 = front30;
            this.Front37 = front37;
            this.Front45 = front45;

            this.East52 = back52;
            this.East60 = back60;
            this.East07 = back7;
            this.East15 = back15;
            this.East00 = back0;
            this.East22 = back22;
            this.East30 = back30;
            this.East37 = back37;
            this.East45 = back45;

        }

        public PaternStickerTypes North52 { get; protected set; }
        public PaternStickerTypes North60 { get; protected set; }
        public PaternStickerTypes North07 { get; protected set; }
        public PaternStickerTypes North15 { get; protected set; }
        public PaternStickerTypes North00 { get; protected set; }
        public PaternStickerTypes North22 { get; protected set; }
        public PaternStickerTypes North30 { get; protected set; }
        public PaternStickerTypes North37 { get; protected set; }
        public PaternStickerTypes North45 { get; protected set; }

        public PaternStickerTypes South52 { get; protected set; }
        public PaternStickerTypes South60 { get; protected set; }
        public PaternStickerTypes South07 { get; protected set; }
        public PaternStickerTypes South15 { get; protected set; }
        public PaternStickerTypes South00 { get; protected set; }
        public PaternStickerTypes South22 { get; protected set; }
        public PaternStickerTypes South30 { get; protected set; }
        public PaternStickerTypes South37 { get; protected set; }
        public PaternStickerTypes South45 { get; protected set; }

        public PaternStickerTypes East52 { get; protected set; }
        public PaternStickerTypes East60 { get; protected set; }
        public PaternStickerTypes East07 { get; protected set; }
        public PaternStickerTypes East15 { get; protected set; }
        public PaternStickerTypes East00 { get; protected set; }
        public PaternStickerTypes East22 { get; protected set; }
        public PaternStickerTypes East30 { get; protected set; }
        public PaternStickerTypes East37 { get; protected set; }
        public PaternStickerTypes East45 { get; protected set; }

        public PaternStickerTypes West52 { get; protected set; }
        public PaternStickerTypes West60 { get; protected set; }
        public PaternStickerTypes West07 { get; protected set; }
        public PaternStickerTypes West15 { get; protected set; }
        public PaternStickerTypes West00 { get; protected set; }
        public PaternStickerTypes West22 { get; protected set; }
        public PaternStickerTypes West30 { get; protected set; }
        public PaternStickerTypes West37 { get; protected set; }
        public PaternStickerTypes West45 { get; protected set; }

        public PaternStickerTypes Front52 { get; protected set; }
        public PaternStickerTypes Front60 { get; protected set; }
        public PaternStickerTypes Front07 { get; protected set; }
        public PaternStickerTypes Front15 { get; protected set; }
        public PaternStickerTypes Front00 { get; protected set; }
        public PaternStickerTypes Front22 { get; protected set; }
        public PaternStickerTypes Front30 { get; protected set; }
        public PaternStickerTypes Front37 { get; protected set; }
        public PaternStickerTypes Front45 { get; protected set; }

        public PaternStickerTypes Back52 { get; protected set; }
        public PaternStickerTypes Back60 { get; protected set; }
        public PaternStickerTypes Back_7 { get; protected set; }
        public PaternStickerTypes Back15 { get; protected set; }
        public PaternStickerTypes Back00 { get; protected set; }
        public PaternStickerTypes Back22 { get; protected set; }
        public PaternStickerTypes Back30 { get; protected set; }
        public PaternStickerTypes Back37 { get; protected set; }
        public PaternStickerTypes Back45 { get; protected set; }
    }
}