
function ajaxSearch(category) {

    const jsonData = JSON.stringify({
        category
    })

    $.ajax({
        url: '/api/Search/SearchByCategory',
        method: 'POST',
        contentType: 'application/json',
        data: jsonData,
        success: function (response) {
            const parent = $('.displayProducts')
            const products = parent.contents()
            products.map((product, element) => {
                $(element).remove()
            })

            if (response.length !== 0) {
                response.map((item) => {
                    const template = `<div class="col-4 col-md-3 col-lg-4" style="min-width: 300px;">
                            <div class="card">
                                <img style="width: 100%;" src="@productImageUrl" alt="Card image cap">
                                <div class="card-body">
                                    <h4 class="card-title">@productName</h4>
                                    <div class="row">
                                        <div class="col">
                                            <a href=/Admin/Products/Details/@productId class="btn btn-outline-success m-auto">Details</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`;

                    const output = template
                        .replace("@productImageUrl", item.imageUrl)
                        .replace("@productName", item.name)
                        .replace("@productId", item.id);

                    console.log(output)
                    parent.append(output);
                });
            } else {
                parent.append('<div class="alert alert-info">No results found</div>')
            }
            
        }
    })
}