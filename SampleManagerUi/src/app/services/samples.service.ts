import { Injectable } from '@angular/core';
import { Response, Http, Headers, RequestOptions  } from '@angular/http';

import { Sample } from '../models/sample';

@Injectable()
export class SamplesService {
  private samplesUrl = "http://localhost:63862/api/samples";
  constructor(private http: Http) { }

  getAllSamples(): Promise<Sample[]> {
    return this.http.get(this.samplesUrl)
      .toPromise()
      .then(response => response.json() as Sample[])
  }

  getSamplesByStatus(statusId: number): Promise<Sample[]> {
    const url = this.samplesUrl + `/status?statusId=${statusId}`;

    return this.http.get(url)
      .toPromise()
      .then(response => response.json() as Sample[]);

  }

  getSamplesByName(nameSearch: string): Promise<Sample[]> {
    const url = this.samplesUrl + `/name?nameSearch=${nameSearch}`;

    return this.http.get(url)
      .toPromise()
      .then(response => response.json() as Sample[]);
  }

  saveSample(sample: Sample): Promise<boolean> {

    return this.http.post(this.samplesUrl, sample)
      .toPromise()
      .then(response => response.ok)
      .catch(err => false);
  }

}
