import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhoneBookModel } from '../Models/PhoneBookModel';

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {

  constructor(private http: HttpClient) { }

  addNewPhoneBookEntry(entry: PhoneBookModel) {
    console.log(entry);
   if(entry){
    return this.http.post(`https://localhost:5001/api/v1/phonebook/addEntry`, entry);
   }
  }

  getPhoneBookEntries() {
    return this.http.get<PhoneBookModel[]>(`https://localhost:5001/api/v1/phonebook/getEntries`);
  }

}
