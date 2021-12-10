
function removeFromCart(id) {

    const jsonData = JSON.stringify({
        id
    })

    $.ajax({
        url: '/api/Cart/RemoveFromCart',
        method: 'POST',
        contentType: 'application/json',
        data: jsonData,
        success: function (response) {
            $(`#${response}`).remove();
        }
    })

}