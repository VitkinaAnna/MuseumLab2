const uri = 'api/Exhibitions';
let exhibitions = [];

function getExhibition() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayExhibition(data))
        .catch(error => console.error('Неможливо знайти.', error));
}

function addExhibition() {
    const addNameTextbox = document.getElementById('add-name');
    const addPriceTextbox = document.getElementById('add-price');
    const addInformationTextbox = document.getElementById('add-information');

    const exhibition = {
        name: addNameTextbox.value.trim(),
        price: addPriceTextbox.value.trim(),
        information : addInformationTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(exhibition)
    })
        .then(response => response.json())
        .then(() => {
            getExhibition();
            addNameTextbox.value = '';
            addPriceTextbox.value = '';
            addInformationTextbox.value = '';
        })
        .catch(error => console.error('Неможливо додати.', error));
    document = getElementById('add-name').value = '';
    document = getElementById('add-price').value = '';
    document = getElementById('add-information').value = '';
}

function deleteExhibition(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getExhibition())
        .catch(error => console.error('Неможливо видалити.', error));
}

function displayEditForm(id) {
    const exhibition = exhibitions.find(exhibition => exhibition.id === id);

    document.getElementById('edit-id').value = exhibition.id;
    document.getElementById('edit-name').value = exhibition.name;
    document.getElementById('edit-price').value = exhibition.price;
    document.getElementById('edit-information').value = exhibition.information;
    document.getElementById('editForm').style.display = 'block';
}

function updateExhibition() {
    const exhibitionId = document.getElementById('edit-id').value;
    const exhibition = {
        id: parseInt(exhibitionId, 10),
        name: document.getElementById('edit-name').value.trim(),
        price: document.getElementById('edit-price').value.trim(),
        information: document.getElementById('edit-information').value.trim(),
    }

    fetch(`${uri}/${exhibitionId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(exhibition)
    })
        .then(() => getExhibition())
        .catch(error => console.error('Неможливо оновити.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayExhibition(data) {
    const tBody = document.getElementById('exhibitions');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(exhibition => {

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Змінити';
        editButton.setAttribute('onclick', `displayEditForm(${exhibition.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteExhibition(${exhibition.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(exhibition.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodePrice = document.createTextNode(exhibition.price);
        td2.appendChild(textNodePrice);

        let td3 = tr.insertCell(2);
        let textNodeInformation = document.createTextNode(exhibition.information);
        td3.appendChild(textNodeInformation)

        let td4= tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    exhibitions = data;
}