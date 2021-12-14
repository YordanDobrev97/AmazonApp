
function setUserProfileSettings() {
    const firstName = $('#firstName').val()
    const lastName = $('#lastName').val()
    const phoneNumber = $('#phoneNumber').val()
    const street = $('#street').val()
    const city = $('#city').val()
    const postcode = $('#postcode').val()
    const country = $('#country').val()

    const jsonData = JSON.stringify({
        firstName,
        lastName,
        phoneNumber,
        street,
        city,
        postcode,
        country
    })

    $.ajax({
        url: '/api/Users/UserSettings',
        method: 'POST',
        contentType: 'application/json',
        data: jsonData,
        success: function (response) {
            if (response === 'Everything was successful!') {
                $('#sucessfullyMessage').html(response).show()
            } else {
                $('#errorMessage').html(response).show()
            }
        }
    })
}