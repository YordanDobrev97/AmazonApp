
function addToCart(productId) {

    const jsonData = JSON.stringify({
        productId
    })

    $.ajax({
        url: '/api/Cart/AddToCart',
        method: 'POST',
        contentType: 'application/json',
        data: jsonData,
        success: function (response) {
            console.log(response)
            $('.message-cart').show().html(response)
        }
    })
}