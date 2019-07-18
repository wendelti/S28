using System;
using System.Collections.Generic;

namespace S28Filler2
{
    public class Definitions
    {
        public enum eRow
        {
            NotFound,
            p5000
, p5001
, p5005
, p5006
, p5007
, p5008
, p5009
, p5112
, p5140
, p5141
, p5142
, p5108
, p5100
, p5170
, p5414
, p5334
, p5340
, p5416
, p5231
, p5331
, p5228
, p5328
, p5227
, p5225
, p5327
, p5419
, p5329
, p5330
, p5411
, p5230
, p5232
, p5425
, p5422
, p5427
, p5415
, p5335
, p5343
, p5407
, p5332
, p5410
, p5323
, p5324
, p5326
, p5403
, p5341
, p5441
, p5442
, p5322
, p5339
, p5336
, p5200
, p6200
, p6618
, p6641
, p6652
, p6632
, p6638
, p6659
, p6645
, p6650
, p6643
, p6628
, p6665
, p6662
, p6642
, p6660
, p6647
, p6654
, p6658
, p6655
, p6657
, p6625
, p6663
, p6622
, p6674
, p6648
, p6629
, p6639
, p6653
, p6636
, p6671
, p6656
, p6630
, p6637
, p6634
, p6635
, p6664
, p6684
, p6600
, p7305
, p7074
, p7071
, p7130
, p7131
, p7132
, p7133
, p7134
, p7135
, p7136
, p7137
, p7182
, p7100
, p9200
, p9305
, p9280
, p9270
, p1540
, p9295
, p8704
, p8708
, p8000

        }

        public enum eCell
        {
            EstoqueAnterior,
            SetMarRec, SetMarEst, SetMarSaida,
            OutAbrRec, OutAbrEst, OutAbrSaida,
            NovMaiRec, NovMaiEst, NovMaiSaida,
            DezJunRec, DezJunEst, DezJunSaida,
            JanJulRec, JanJulEst, JanJulSaida,
            FevAgoRec, FevAgoEst, FevAgoSaida
        }

        public class Mapping
        {
            public Dictionary<eRow, Dictionary<eCell, string>> map;

            public Mapping()
            {
                var i = 1;
                map = new Dictionary<eRow, Dictionary<eCell, string>>();
                foreach (eRow item in Enum.GetValues(eRow.p5000.GetType()))
                {
                    if (item != eRow.NotFound)
                    {
                        map.Add(item, new Dictionary<eCell, string>()
                            {
                                { eCell.EstoqueAnterior, Key(i++)},
                                { eCell.SetMarRec, Key(i++)},
                                { eCell.SetMarEst, Key(i++)},
                                { eCell.SetMarSaida, Key(i++)},
                                { eCell.OutAbrRec, Key(i++)},
                                { eCell.OutAbrEst, Key(i++)},
                                { eCell.OutAbrSaida, Key(i++)},
                                { eCell.NovMaiRec, Key(i++)},
                                { eCell.NovMaiEst, Key(i++)},
                                { eCell.NovMaiSaida, Key(i++)},
                                { eCell.DezJunRec, Key(i++)},
                                { eCell.DezJunEst, Key(i++)},
                                { eCell.DezJunSaida, Key(i++)},
                                { eCell.JanJulRec, Key(i++)},
                                { eCell.JanJulEst, Key(i++)},
                                { eCell.JanJulSaida, Key(i++)},
                                { eCell.FevAgoRec, Key(i++)},
                                { eCell.FevAgoEst, Key(i++)},
                                { eCell.FevAgoSaida, Key(i++ ) }
                            }
                        );

                    }
                }

            }

            private string Key(int v)
            {
                if (v > 1083)
                    return $"{v - 1083}_2";
                else
                    return v.ToString();
            }
        }

    }


}
