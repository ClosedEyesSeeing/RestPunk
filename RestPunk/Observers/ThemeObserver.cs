using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Observers
{
	sealed class ThemeObserver : IObserver<ThemeVariant>
	{
		private readonly Action _onThemeChanged;
		public ThemeObserver(Action onThemeChanged) => _onThemeChanged = onThemeChanged;

		public void OnNext(ThemeVariant value) => _onThemeChanged();
		public void OnError(Exception error) { }
		public void OnCompleted() { }
	}
}
