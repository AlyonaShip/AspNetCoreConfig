import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-editor-data',
  templateUrl: './editor-data.component.html',
  styleUrls: ['./editor-data.component.css']
})
export class EditorDataComponent implements OnInit {
  public editorDataset: Array<string>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<string>>(baseUrl + 'privatedata/editor-data').subscribe(
      result => {
        this.editorDataset = result;
      },
      error => {
        console.log("editordata says: " + error);
      }
    );
  }

  ngOnInit() {
  }

}
