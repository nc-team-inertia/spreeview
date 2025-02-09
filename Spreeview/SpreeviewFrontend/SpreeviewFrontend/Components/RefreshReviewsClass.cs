namespace SpreeviewFrontend.Components
{
    public class RefreshReviewsClass
    {
		private bool _refresh;
		public event Action? OnRefreshChanged;

		public bool Refresh
		{
			get => _refresh;
			set
			{
				_refresh = value;
				OnRefreshChanged?.Invoke(); // Notify Blazor that this value changed
			}
		}
	}
}
