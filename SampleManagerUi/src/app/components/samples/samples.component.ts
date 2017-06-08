import { Component, OnInit } from '@angular/core';
import { SamplesService } from '../../services/samples.service';
import { Sample } from '../../models/sample';

@Component({
  selector: 'app-samples',
  templateUrl: './samples.component.html',
  styleUrls: ['./samples.component.css']
})
export class SamplesComponent implements OnInit {
  private samples: Sample[];

  constructor(private samplesService: SamplesService ) { }

  ngOnInit() {
  }

  getSamples() {
    this.samplesService.getAllSamples()
      .then( samples => {
        this.samples = samples;
      });
  }

}
