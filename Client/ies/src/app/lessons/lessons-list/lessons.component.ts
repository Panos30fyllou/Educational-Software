import { Component, OnInit } from '@angular/core';
import { Lesson } from '../../models/lesson';

@Component({
  selector: 'app-lessons',
  templateUrl: './lessons.component.html',
  styleUrls: ['./lessons.component.scss']
})
export class LessonsComponent implements OnInit {

  lessons: Lesson[] = []
  constructor() { }

  ngOnInit(): void {
    for (let i = 0; i < 5; i++)
      this.lessons.push(new Lesson())
  }

}
