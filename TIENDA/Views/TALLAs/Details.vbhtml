﻿@ModelType TIENDA.TALLA
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>TALLA</h4>
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
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.IdTalla }) |
    @Html.ActionLink("Back to List", "Index")
</p>
