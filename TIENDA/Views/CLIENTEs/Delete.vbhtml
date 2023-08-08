@ModelType TIENDA.CLIENTE

@Code
    ViewData("Title") = "Delete"
End Code

<div class="container">
    <h2>Delete</h2>

    <div class="alert alert-danger">
        <h3>Are you sure you want to delete this?</h3>
    </div>

    <div class="card">
        <div class="card-header">
            <h4>CLIENTE</h4>
        </div>
        <div class="card-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Apellido)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Apellido)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Email)
                </dt>
                <dd>
                    @Html.DisplayFor(Function(model) model.Email)
                </dd>
            </dl>
        </div>
    </div>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div Class="form-group mt-3">
            <div Class="text-center">
                <button type = "submit" Class="btn btn-danger">Delete</button>
                @Html.ActionLink("Back to List", "Index", Nothing, New With {.class = "btn btn-default ml-2"})
            </div>
        </div>
    End Using
</div>
