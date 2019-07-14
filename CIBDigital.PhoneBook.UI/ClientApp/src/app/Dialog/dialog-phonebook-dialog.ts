import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PhoneBookModel } from '../models/PhoneBookModel';

@Component({
    selector: 'dialog-phonebook-dialog',
    templateUrl: 'dialog-phonebook-dialog.html',
  })
  export class DialogPhoneBookDialog {
   phoneBook = new PhoneBookModel;
      constructor(public dialogRef: MatDialogRef<DialogPhoneBookDialog>) { }

        addNewEntry(phoneBook:PhoneBookModel): void {
          var pattern="[0-9]{10}"
            if(phoneBook.name && phoneBook.phoneNumber.toString().match(pattern))
            {
              this.dialogRef.close(phoneBook);
            }
            else{
              //or else use validation form and minlength and maxlenth
              alert("Phone Number length must be 10 digits and Name can not be empty");
            }
          }

        cancel() {
            this.dialogRef.close();
          }
  
  }
  