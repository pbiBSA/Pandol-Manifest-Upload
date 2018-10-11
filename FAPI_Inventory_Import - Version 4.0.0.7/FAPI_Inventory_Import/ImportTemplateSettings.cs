using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAPI_Inventory_Import
{
    //holds the template settings values for the application
    class ImportTemplateSettings
    {
        //Template Variables
        public string TemplateName { get; set; }
        public int ExporterRow { get; set; }
        public int ExporterColumn { get; set; }
        public int DepartureDateRow { get; set; }
        public int DepartureDateColumn { get; set; }
        public int VesselNumberRow { get; set; }
        public int VesselNumberColumn { get; set; }
        public int VesselNameRow { get; set; }
        public int VesselNameColumn { get; set; }
        public int VesselDestinationRow { get; set; }
        public int VesselDestinationColumn { get; set; }
        public int PalletPrefixRow { get; set; }
        public int PalletPrefixColumn { get; set; }
        public int TagNumberRow { get; set; }
        public int TagNumberColumn { get; set; }
        public int CommodityRow { get; set; }
        public int CommodityColumn { get; set; }
        public int VarietyRow { get; set; }
        public int VarietyColumn { get; set; }
        public int StyleRow { get; set; }
        public int StyleColumn { get; set; }
        public int SizeRow { get; set; }
        public int SizeColumn { get; set; }
        public int GradeRow { get; set; }
        public int GradeColumn { get; set; }
        public int LabelRow { get; set; }
        public int LabelColumn { get; set; }
        public int PalletTypeRow { get; set; }
        public int PalletTypeColumn { get; set; }
        public int InventoryQuantityRow { get; set; }
        public int InventoryQuantityColumn { get; set; }
        public int FirstPackDateRow { get; set; }
        public int FirstPackDateColumn { get; set; }
        public int GrowerNumberRow { get; set; }
        public int GrowerNumberColumn { get; set; }
        public int HatchRow { get; set; }
        public int HatchColumn { get; set; }
        public int DeckRow { get; set; }
        public int DeckColumn { get; set; }
        public int FumigatedRow { get; set; }
        public int FumigatedColumn { get; set; }
        public int BillOfLadingRow { get; set; }
        public int BillOfLadingColumn { get; set; }
        public int MemoRow { get; set; }
        public int MemoColumn { get; set; }
        public int AddStyleSizeColumns { get; set; }
        public int AddGradeColumn { get; set; }
        public int AddPalletTypeColumn { get; set; }
        public int AddMemoColumn { get; set; }
        public int AddHatchDeckColumn { get; set; }
        public int PackCodeRow { get; set; }
        public int PackCodeColumn { get; set; }
        public int Custom_1 { get; set; }
        public int Other { get; set; }
        public string DataSheet { get; set; }
        public string DataRange { get; set; }
        public string Special_Processing { get; set; }

        //method to return row and column values as a pair when called by name
        public DataItemLocation DataColumnLocation(string value)
        {
            if (value == "Exporter")
            {
                DataItemLocation dl = new DataItemLocation(ExporterRow, ExporterColumn);
                return dl;
            }
            else if (value == "DepartureDate")
            {
                DataItemLocation dl = new DataItemLocation(DepartureDateRow, DepartureDateColumn);
                return dl;
            }
            else if (value == "VesselNumber")
            {
                DataItemLocation dl = new DataItemLocation(VesselNumberRow, VesselNumberColumn);
                return dl;
            }
            else if (value == "VesselName")
            {
                DataItemLocation dl = new DataItemLocation(VesselNameRow, VesselNameColumn);
                return dl;
            }
            else if (value == "Destination")
            {
                DataItemLocation dl = new DataItemLocation(VesselDestinationRow, VesselDestinationColumn);
                return dl;
            }
            else if (value == "Prefix")
            {
                DataItemLocation dl = new DataItemLocation(PalletPrefixRow, PalletPrefixColumn);
                return dl;
            }
            else if (value == "TagNumber")
            {
                DataItemLocation dl = new DataItemLocation(TagNumberRow, TagNumberColumn);
                return dl;
            }
            else if (value == "Commodity")
            {
                DataItemLocation dl = new DataItemLocation(CommodityRow, CommodityColumn);
                return dl;
            }
            else if (value == "Variety")
            {
                DataItemLocation dl = new DataItemLocation(VarietyRow, VarietyColumn);
                return dl;
            }
            else if (value == "Style")
            {
                DataItemLocation dl = new DataItemLocation(StyleRow, StyleColumn);
                return dl;
            }
            else if (value == "Size")
            {
                DataItemLocation dl = new DataItemLocation(SizeRow, SizeColumn);
                return dl;
            }
            else if (value == "Grade")
            {
                DataItemLocation dl = new DataItemLocation(GradeRow, GradeColumn);
                return dl;
            }
            else if (value == "Label")
            {
                DataItemLocation dl = new DataItemLocation(LabelRow, LabelColumn);
                return dl;
            }
            else if (value == "PalletType")
            {
                DataItemLocation dl = new DataItemLocation(PalletTypeRow, PalletTypeColumn);
                return dl;
            }
            else if (value == "Quantity")
            {
                DataItemLocation dl = new DataItemLocation(InventoryQuantityRow, InventoryQuantityColumn);
                return dl;
            }
            else if (value == "FirstPackDate")
            {
                DataItemLocation dl = new DataItemLocation(FirstPackDateRow, FirstPackDateColumn);
                return dl;
            }
            else if (value == "PackCode")
            {
                DataItemLocation dl = new DataItemLocation(PackCodeRow, PackCodeColumn);
                return dl;
            }

                      
            //If none of the above return a -1,-1 pair
            else
            {
                //Create a custom exception instance and throw if no matches are found
                TemplateSettingsException  e =
                    new TemplateSettingsException(
                    "Could not find ImportSetting field.  The value '" + value 
                    + "' was searched for and could not be found in the object." 
                    + this.ToString());
                
                throw e;
            }            
        }
  
    }
}
