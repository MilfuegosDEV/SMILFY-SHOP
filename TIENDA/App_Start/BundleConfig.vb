Imports System.Web.Optimization

Public Module BundleConfig
    ' Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New Bundle("~/bundles/jquery").Include(
                                "~/Scripts/jquery-{version}.js"))

        bundles.Add(New Bundle("~/bundles/complementos").Include(
            "~/Scripts/scripts.js",
            "~/Scripts/fontawesome/all.min.js",
            "~/Scripts/DataTables/jquery.dataTables.js",
            "~/Scripts/DataTables/dataTables.responsive.js"))


        bundles.Add(New Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/DataTables/css/responsive.dataTables.css"))

    End Sub
End Module

