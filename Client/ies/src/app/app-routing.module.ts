import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LessonComponent } from './lessons/lesson-detailed/lesson.component';
import { LessonsComponent } from './lessons/lessons-list/lessons.component';
import { ProfileComponent } from './profile/profile.component';
import { TestComponent } from './tests/test-detailed/test.component';
import { TestsComponent } from './tests/tests-list/tests.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', redirectTo: 'landing', pathMatch: 'full' },
  { path: 'test', component: TestComponent},
  { path: 'tests', component: TestsComponent},
  { path: 'lesson', component: LessonComponent},
  { path: 'lessons', component: LessonsComponent},
  { path: 'profile', component: ProfileComponent}
  // { path: 'landing', component: AppComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
