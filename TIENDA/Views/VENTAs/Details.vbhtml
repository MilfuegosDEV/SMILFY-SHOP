@ModelType TIENDA.VENTA
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>VENTA</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cantidad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cantidad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fecha)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CLIENTE.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CLIENTE.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PRENDA.IdPrenda)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PRENDA.IdPrenda)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.IdVenta }) |
    @Html.ActionLink("Back to List", "Index")
</p>
