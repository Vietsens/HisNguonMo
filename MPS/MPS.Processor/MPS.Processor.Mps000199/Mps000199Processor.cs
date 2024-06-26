/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using Inventec.Core;
using MOS.EFMODEL.DataModels;
using MPS.Processor.Mps000199.PDO;
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000199
{
    class Mps000199Processor : AbstractProcessor
    {
        Mps000199PDO rdo;
        List<Mps000199ADO> _ListAdo = null;

        public Mps000199Processor(CommonParam param, PrintData printData)
            : base(param, printData)
        {
            rdo = (Mps000199PDO)rdoBase;
            _ListAdo = new List<Mps000199ADO>();
        }

        public override bool ProcessData()
        {
            bool result = false;
            try
            {
                Inventec.Common.FlexCellExport.ProcessSingleTag singleTag = new Inventec.Common.FlexCellExport.ProcessSingleTag();
                Inventec.Common.FlexCellExport.ProcessObjectTag objectTag = new Inventec.Common.FlexCellExport.ProcessObjectTag();
                SetSingleKey();
                store.ReadTemplate(System.IO.Path.GetFullPath(fileName));
                singleTag.ProcessData(store, singleValueDictionary);
                objectTag.AddObjectData(store, "ListMediMate", _ListAdo);
                if (rdo._ListIpmMestUser == null || rdo._ListIpmMestUser.Count < 1)
                {
                    rdo._ListIpmMestUser = new List<V_HIS_IMP_MEST_USER>();
                }
                objectTag.AddObjectData(store, "ListImpMestUser", rdo._ListIpmMestUser);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return result;
        }

        private void SetSingleKey()
        {
            try
            {
                decimal sumPrice = 0;
                if (rdo._ImpMestMedicines != null && rdo._ImpMestMedicines.Count > 0)
                {
                    // sắp xếp theo thứ tự tăng dần của id
                    rdo._ImpMestMedicines = rdo._ImpMestMedicines.OrderBy(o => o.ID).ToList();
                    foreach (var item in rdo._ImpMestMedicines)
                    {
                        _ListAdo.Add(new Mps000199ADO(item, rdo._ListMedicalContract));
                        if (!item.PRICE.HasValue)
                            continue;
                        sumPrice += item.AMOUNT * item.PRICE.Value * (1 + (item.VAT_RATIO ?? 0));
                    }
                }
                if (rdo._ImpMestMaterials != null && rdo._ImpMestMaterials.Count > 0)
                {
                    //sắp xếp theo thứ tự tăng dần của id
                    rdo._ImpMestMaterials = rdo._ImpMestMaterials.OrderBy(o => o.ID).ToList();
                    foreach (var item in rdo._ImpMestMaterials)
                    {
                        _ListAdo.Add(new Mps000199ADO(item, rdo._ListMedicalContract));
                        if (!item.PRICE.HasValue)
                            continue;
                        sumPrice += item.AMOUNT * item.PRICE.Value * (1 + (item.VAT_RATIO ?? 0));
                    }
                }

                if (rdo._ImpMestBloods != null && rdo._ImpMestBloods.Count > 0)
                {
                    // sắp xếp theo thứ tự tăng dần của id
                    rdo._ImpMestBloods = rdo._ImpMestBloods.OrderBy(o => o.ID).ToList();
                    foreach (var item in rdo._ImpMestBloods)
                    {
                        _ListAdo.Add(new Mps000199ADO(item));
                        if (!item.PRICE.HasValue)
                            continue;
                        sumPrice += item.PRICE.Value * (1 + (item.VAT_RATIO ?? 0));
                    }
                }
                string totalPriceSeparate = Inventec.Common.Number.Convert.NumberToString(sumPrice, HIS.Desktop.LocalStorage.ConfigApplication.ConfigApplications.NumberSeperator);
                SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.TOTAL_PRICE, sumPrice));
                SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.TOTAL_PRICE_SEPARATE, totalPriceSeparate));
                SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.SUM_PRICE, Inventec.Common.Number.Convert.NumberToStringRoundMax4(sumPrice)));
                string sumPriceString = String.Format("{0:0.####}", Inventec.Common.Number.Convert.NumberToNumberRoundMax4(sumPrice));
                SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.SUM_PRICE_TEXT, Inventec.Common.String.Convert.CurrencyToVneseString(sumPriceString)));

                if (rdo._initImpMest != null)
                {
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.Titles, "ĐẦU KỲ"));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.IMP_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._initImpMest.IMP_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._initImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._initImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_SEPARATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateStringSeparateString(rdo._initImpMest.CREATE_TIME ?? 0)));

                    AddObjectKeyIntoListkey<V_HIS_IMP_MEST>(rdo._initImpMest, false);
                }
                else if (rdo._inveImpMest != null)
                {
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.Titles, "KIỂM KÊ"));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.IMP_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._inveImpMest.IMP_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._inveImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._inveImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_SEPARATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateStringSeparateString(rdo._inveImpMest.CREATE_TIME ?? 0)));

                    AddObjectKeyIntoListkey<V_HIS_IMP_MEST>(rdo._inveImpMest, false);
                }
                else if (rdo._otherImpMest != null)
                {
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.Titles, "KHÁC"));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.IMP_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._otherImpMest.IMP_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_TIME_STR, Inventec.Common.DateTime.Convert.TimeNumberToTimeString(rdo._otherImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._otherImpMest.CREATE_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000199ExtendSingleKey.CREATE_DATE_SEPARATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateStringSeparateString(rdo._otherImpMest.CREATE_TIME ?? 0)));

                    AddObjectKeyIntoListkey<V_HIS_IMP_MEST>(rdo._otherImpMest, false);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
