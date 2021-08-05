import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { error } from '@angular/compiler/src/util';
import { User } from './User';

@Component({
  selector: 'app-private-data',
  templateUrl: './private-data.component.html',
  styleUrls: ['./private-data.component.css']
})
export class PrivateDataComponent implements OnInit {
  public privateDataset: Array<User>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'privatedata/get-users').subscribe(
      result => {
        this.privateDataset = result;
      },
      error => {
        console.log("privatedata says: " + error);
      }
    );
  }

  ngOnInit() {
  }

}
