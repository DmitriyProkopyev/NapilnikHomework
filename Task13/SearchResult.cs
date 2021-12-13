namespace Model
{
    public class SearchResult : Result
    {
        public readonly SearchState State;

        public SearchResult(bool success, SearchState state) : base(success) =>
            State = state;

        public enum SearchState
        {
            Success,
            Fail,
            NotFound,
            Error
        }
    }
}
