namespace Medical.API.Features.Medicine.Models
{
    public class MedicineParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize
        {
            get => _pageSize;
            // If the value is greater than page size, then return MaxPageSize, else value
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
