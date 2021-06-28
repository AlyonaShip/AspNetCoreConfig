import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public setting: Settings
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Settings>(baseUrl + 'weatherforecast/get settings').subscribe(result => {
      this.setting = result;
    }, error => console.error(error));
  }
}

export class Settings {
  environmentSettings: EnvironmentSettings;
  allowedOrigins: AllowedOrigins
    }

export class EnvironmentSettings {
  name: string;
}

export class AllowedOrigins {
  link: Array<string>;
}
