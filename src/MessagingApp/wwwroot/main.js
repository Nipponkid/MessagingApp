'use strict';

const displayContacts = contacts => {
    contacts.forEach(contact => {
        const div = document.createElement('div');
        const text = document.createTextNode(`${contact.firstName} ${contact.lastName}`);
        div.appendChild(text);
        document.body.appendChild(div);
    });
};

fetch('api/contacts')
    .then(response => response.json())
    .then(json => {
        displayContacts(json);
    });