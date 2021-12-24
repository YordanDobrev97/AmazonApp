
function pagination(products) {
    let currentPage = 1
    let productsPerPage = 3
    let totalPages = Math.ceil(products.length / productsPerPage)
   
    function changePage(page) {
        var output = $('#items')

        if (page < 1) page = 1
        if (page > totalPages) page = totalPages

        for (var i = (page - 1) * productsPerPage; i < (page * productsPerPage) && i < products.length; i++) {
            let template = `
                <div class="list-product col-lg-4 col-md-6">
                     <div class="card d-flex flex-column align-items-center">
                          <div class="product-name">product.Name</div>
                               <div class="card-img">
                                    <img src="product.ImageUrl" alt="product image">
                               </div>
                               <div class="card-body pt-5">
                                    <div class="d-flex align-items-center price text-md-center">
                                         <span><i class="fas fa-dollar-sign"></i></span>
                                         <div class="text-md-center">product.Price</div>
                                    </div>
                                    <div class="d-flex align-items-center">
                                         <a href="/Products/Details/product.Id" class="w-75 btn btn-outline-success">Details</a>
                                         <button onclick="addToCart('product.Id')" class="w-75 btn btn-outline-warning" style="min-width: 120px; margin-left: 8px;">Add to cart</button>
                                    </div>
                              </div>
                          </div>
                    </div>
                </div>
`
            const product = products[i]
            template = template
                .replace('product.Name', product.name)
                .replace('product.ImageUrl', product.imageUrl)
                .replace('product.Price', product.price)
                .replaceAll('product.Id', product.id)

            output.append(template)
        }
    }

    const handleNewPage = (e) => {
        const newPage = Number(e.target.innerHTML)
        $('#items').html("")
        changePage(newPage)
    }

    const displayTotalPages = (totalPages) => {
        const pagination = $('.pagination')

        for (let i = 1; i <= totalPages; i++) {
            const li = document.createElement('li')
            li.className = 'page-link'
            li.textContent = i;
            li.addEventListener('click', handleNewPage)
            pagination.append(li)
        }
    }

    const displayPartProducts = (products) => {
        const container = $('#items')
        container.html('')

        for (let product of products) {
            let template = `
                <div class="list-product col-lg-4 col-md-6">
                     <div class="card d-flex flex-column align-items-center">
                          <div class="product-name">product.Name</div>
                               <div class="card-img">
                                    <img src="product.ImageUrl" alt="product image">
                               </div>
                               <div class="card-body pt-5">
                                    <div class="d-flex align-items-center price text-md-center">
                                         <span><i class="fas fa-dollar-sign"></i></span>
                                         <div class="text-md-center">product.Price</div>
                                    </div>
                                    <div class="d-flex align-items-center">
                                         <a href="/Products/Details/product.Id" class="w-75 btn btn-outline-success">Details</a>
                                         <button onclick="addToCart('product.Id')" class="w-75 btn btn-outline-warning" style="min-width: 120px; margin-left: 8px;">Add to cart</button>
                                    </div>
                              </div>
                          </div>
                    </div>
                </div>
`
            template = template
                .replace('product.Name', product.name)
                .replace('product.ImageUrl', product.imageUrl)
                .replace('product.Price', product.price)
                .replaceAll('product.Id', product.id)

            container.append(template)
        }
    }

    if (products.length > 0) {
        displayTotalPages(totalPages)
        displayPartProducts(products.slice(currentPage - 1, productsPerPage))
    }
}