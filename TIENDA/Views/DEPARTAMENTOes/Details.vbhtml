@ModelType TIENDA.DEPARTAMENTO
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>DEPARTAMENTO</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.IdDepartamento }) |
    @Html.ActionLink("Back to List", "Index")
</p>
