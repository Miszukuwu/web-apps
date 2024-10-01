function buttonClick() {
    alert("Kliknięto guzik");
}
function colorChange() {
    let color = document.querySelector("select").value;
    document.querySelector("body").style.color = color;
}