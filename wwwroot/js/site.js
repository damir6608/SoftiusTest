
let isErr = false
function StudentsNumHandler() {
    let val = document.getElementById("LabelStudentsNumber").value;
    if (isErr && (val < 2 || val > 100)) {
        return
    }
    if (val < 2 || val > 100) {
        let error = document.createElement('label');
        error.innerText = "Количество студентов должно быть в промежутке от 2 до 100"
        error.style.color = "#f00"
        error.id = "error"
        document.getElementById("inputStudents").insertAdjacentElement('beforebegin', error);
        isErr = true
        return 0;
    }
       
    else {
        document.getElementById("error").parentNode.removeChild(document.getElementById("error"));
            isErr = false;
    }
}
function CreateFields() {
    if (!isErr) {
        let val = document.getElementById("LabelStudentsNumber").value;
        let i = 0;
        var element;
        element = document.getElementById("MessageLimitField");
        if (element) {
            element.innerHTML = "";
        }
        let count = 1;
        for (i; i < val; i++) {
            var inp = new Array();;
            let label = document.createElement('label');
            let tab = document.createElement('hr');
            inp[i] = document.createElement('input');
            inp[i].type = 'number';
            inp[i].name = 'messagesLimit';
            inp[i].id = 'messagesLimit';
            inp[i].value = '0';
            inp[i].style.width = 20;
            tab.style.width = 10;
            label.innerText = (i + 1) + ".";
            document.getElementById("MessageLimitField").insertAdjacentElement('beforeend', tab);
            document.getElementById("MessageLimitField").insertAdjacentElement('beforeend', label);
            document.getElementById("MessageLimitField").insertAdjacentElement('beforeend', inp[i]);
        }
    }
    Submit();
}
function Submit() {
    let val = document.getElementById("LabelStudentsNumber").value;
    let form = document.getElementById("MainForm");
    let btn = document.getElementById("SubmitBtn");
    
    if (!(val > 1 && val < 101)) {
        btn.setAttribute('disabled', true);
    } else {
        btn.removeAttribute('disabled');
    }
}
