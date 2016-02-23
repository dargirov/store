namespace OnlineStore.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/colorbox").Include("~/Scripts/jquery.colorbox.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/bootstrap").Include("~/Areas/Administration/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/admin/jqueryui").Include("~/Areas/Administration/Scripts/jquery-ui.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(/*"~/Content/bootstrap.css", */"~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/admin/css").Include("~/Areas/Administration/Content/bootstrap.css", "~/Areas/Administration/Content/site.css", "~/Areas/Administration/Content/jquery-ui.min.css", "~/Areas/Administration/Content/jquery-ui.structure.min.css", "~/Areas/Administration/Content/jquery-ui.theme.min.css"));
        }
    }
}
