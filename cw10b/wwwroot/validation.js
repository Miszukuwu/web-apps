function validate(){
    let isValid = true;
    let title = document.getElementById("Title").value;
    let publisher = document.getElementById("Publisher").value;
    let price = document.getElementById("Price").value;
    let releaseYear= document.getElementById("ReleaseYear").value;
    if (title == "" || title == " "){
        document.getElementById("TitleValid").innerHTML = "Tytuł jest wymagany";
        isValid = false;
    } else {
        document.getElementById("TitleValid").innerHTML = "";
    }
    if (publisher == "" || publisher == " "){
        document.getElementById("PublisherValid").innerHTML = "Wydawca jest wymagany";
    } else {
        document.getElementById("PublisherValid").innerHTML = "";
    }
    if (price==0){
        document.getElementById("PriceValid").innerHTML = "Cena jest wymagana";
        isValid = false;
    } else if (price<0) {
        document.getElementById("PriceValid").innerHTML = "Cena musi być większa od 0";
        isValid = false;
    } else {
        document.getElementById("PriceValid").innerHTML = "";
    }
    if (releaseYear==0){
        document.getElementById("ReleaseYearValid").innerHTML = "Rok wydania jest wymagany";
        isValid = false;
    } else if (releaseYear<0) {
        document.getElementById("ReleaseYearValid").innerHTML = "Rok wydania musi być większy od 0";
        isValid = false;
    } else {
        document.getElementById("ReleaseYearValid").innerHTML = "";
    }
    if (isValid){
        document.myForm.submit();
    }
}