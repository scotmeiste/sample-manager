import { Component, OnInit } from '@angular/core';
import { SamplesService } from '../../services/samples.service';
import { Sample } from '../../models/sample';

@Component({
  selector: 'app-samples-name',
  templateUrl: './samples-name.component.html',
  styleUrls: ['./samples-name.component.css']
})
export class SamplesNameComponent implements OnInit {
  private samples: Sample[];
  private nameSearch: string;

  constructor(private samplesService: SamplesService ) { }

  ngOnInit() {
  }

  getSamples() {
    this.samplesService.getSamplesByName(this.nameSearch)
      .then( samples => {
        this.samples = samples;
      });
  }

}
