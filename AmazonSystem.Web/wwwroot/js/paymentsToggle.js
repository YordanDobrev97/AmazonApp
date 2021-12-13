
function creditCardPayment() {
    $('.credit-card-payment').show();
    $('.paypal-payment').hide();
    $('.cash-payment').hide();
    $('.shipping-method').html('CreditCard')
    $('.shipping-method-input').val('CreditCard')
}

function paypalPayment() {
    $('.paypal-payment').show();
    $('.credit-card-payment').hide();
    $('.cash-payment').hide();
    $('.shipping-method').html('Paypal')
    $('.shipping-method-input').val('Paypal')
}

function cashPayment() {
    $('.cash-payment').show();
    $('.paypal-payment').hide();
    $('.credit-card-payment').hide();
    $('.shipping-method').html('Cash')
    $('.shipping-method-input').val('Cash')
}