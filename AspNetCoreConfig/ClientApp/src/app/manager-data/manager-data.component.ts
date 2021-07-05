import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-manager-data',
  templateUrl: './manager-data.component.html',
  styleUrls: ['./manager-data.component.css']
})
export class ManagerDataComponent implements OnInit {
  public managerDataset: Array<string>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<string>>(baseUrl + 'privatedata/manager-data').subscribe(
      result => {
        this.managerDataset = result;
      },
      error => {
        console.log("managerdata says: " + error);
      }
    );
  }

  ngOnInit() {
  }

}
