namespace LoFiEffects.WPF
{
    /// <summary>
    /// Provides helper functions for Uri's.
    /// </summary>
    internal static class UriHelper
    {
        #region StaticMethods

        /// <summary>
        /// Create a Uri for a resource.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        /// <returns>The Uri.</returns>
        public static Uri FromResource(string resourceName)
        {
            var pack = @"pack://application:,,,/LoFiEffects.WPF;component/";
            return new Uri($"{pack}{resourceName}", UriKind.RelativeOrAbsolute);
        }

        #endregion
    }
}
