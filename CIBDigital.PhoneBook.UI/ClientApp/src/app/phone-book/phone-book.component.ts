import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table'
import {MatDialog} from '@angular/material/dialog';
import {DialogPhoneBookDialog } from '../Dialog/dialog-phonebook-dialog';
import { PhoneBookModel } from '../models/PhoneBookModel';
import { PhonebookService } from '../service/phonebook.service';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent implements OnInit {
 
  displayedColumns: string[] = ['initial','name','phoneNumber'];
  dataSource: MatTableDataSource<PhoneBookModel>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;


  constructor(public dialog: MatDialog,public phonebookService: PhonebookService) {
    this.getPhoneBookEntries();
   }

  ngOnInit() { 
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogPhoneBookDialog, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(data => {
        if(data){
          this.addNewPhonBookEntry(data);
        }else{
          console.log("Dialog is empty")
        }
    });
  }

  addNewPhonBookEntry(entry:PhoneBookModel){
    this.phonebookService.addNewPhoneBookEntry(entry).pipe(first()).subscribe(data=>{
      this.getPhoneBookEntries();
    },
    error=>{
      console.log(error);
    });
  }

  getPhoneBookEntries(){
    let phoneBookList : PhoneBookModel[];
    this.phonebookService.getPhoneBookEntries().pipe(first()).subscribe(data=>{
      this.dataSource = new MatTableDataSource(data);    
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;    
      },
    error =>{
      //log to a source
      console.log(error);
    });
   }

}

