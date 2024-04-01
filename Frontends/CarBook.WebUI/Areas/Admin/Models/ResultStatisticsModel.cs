namespace CarBook.WebUI.Areas.Admin.Models
{
    public class ResultStatisticsModel
    {
        public int AuthorCount { get; set; }
        public int AuthorCountRand { get; set; }
        public int BlogCount { get; set; }
        public int BlogCountRand { get; set; }
        public int BrandCount { get; set; }
        public int BrandCountRand { get; set; }
        public int CarCount { get; set; }
        public int CarCountRand { get; set; }
        public int LocationCount { get; set; }
        public int LocationRand { get; set; }
        public int CarCountByGasolineOrDiesel { get; set; }
        public int CarCountByGasolineOrDieselRand { get; set; }
        public int CarCountByElectric { get; set; }
        public int CarCountByElectricRand { get; set; }
        public int CarCountByKmLessThan1000 { get; set; }
        public int CarCountByKmLessThan1000Rand { get; set; }
        public int CarCountByTransmissionIsAuto { get; set; }
        public int CarCountByTransmissionIsAutoRand { get; set; }
        public string? DailyAveragePrice { get; set; }
        public int DailyAveragePriceRand { get; set; }
        public string? WeeklyAveragePrice { get; set; }
        public int WeeklyAveragePriceRand { get; set; }
        public string? MonthlyAveragePrice { get; set; }
        public int MonthlyAveragePriceRand { get; set; }
        public string? MostCountBrand { get; set; }
        public int MostCountBrandRand { get; set; }
        public string? MostCommentBlog { get; set; }
        public int MostCommentBlogRand { get; set; }
        public string? BrandAndModelDailyPriceIsMax { get; set; }
        public int BrandAndModelDailyPriceIsMaxRand { get; set; }
        public string? BrandAndModelDailyPriceIsMin { get; set; }
        public int BrandAndModelDailyPriceIsMinRand { get; set; }
    }
}
