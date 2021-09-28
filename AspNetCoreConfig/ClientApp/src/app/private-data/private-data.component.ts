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
  public userNameToSearch: string;
  public userFound: User;
  private apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
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

  search() {
    this.http.get<User>(this.apiUrl + `privatedata/find-user/${this.userNameToSearch}`).subscribe(
      result => {
        this.userFound = result;
      },
      error => {
        console.log("private data says: " + error);
      }
    );
  }

}
