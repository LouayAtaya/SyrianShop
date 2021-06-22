import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-content-header',
  templateUrl: './content-header.component.html',
  styleUrls: ['./content-header.component.sass']
})
export class ContentHeaderComponent implements OnInit {

  @Input() title;

  @Input() rootPath;

  @Input() subPath;


  constructor() { }

  ngOnInit(): void {
  }

}
