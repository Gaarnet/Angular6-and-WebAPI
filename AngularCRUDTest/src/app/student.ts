import { Course } from './course';

export class Student {
  constructor(
    public Id: number
  ) { }
  public Name: string
  public Age: number
  public courses: Course[]
}
