
function increaseProductQuantity(id) {
    const jsonData = JSON.stringify({
        id
    })

    $.ajax({
        url: '/api/Cart/IncreaseProductQuantity',
        method: 'POST',
        contentType: 'application/json',
        data: jsonData,
        success: function (response) {
            $(`#${response.id}`).html(response.updateQuantity)
            $('#totalPrice').html(response.totalPrice)
            $('.doublePrice').html(response.doublePrice)
            
        }
    })
}

function decreaseProductQuantity(id) {
    console.log(id)
}