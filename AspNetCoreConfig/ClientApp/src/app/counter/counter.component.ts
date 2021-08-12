import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { User } from './User';


@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public privateDataset: Array<User>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<User>>(baseUrl + 'privatedata/get-user').subscribe(
      result => {
        this.privateDataset = result;
      },
      error => {
        console.log("privatedata says: " + error);
      }
    );
  }

}
