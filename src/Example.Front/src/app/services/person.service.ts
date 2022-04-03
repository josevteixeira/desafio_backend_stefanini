import { HttpClient } from '@angular/common/http'
import { Person } from '../models/person.model';

export class PersonService {
  private readonly apiEndpoint = `http://localhost:5194/api/Person`;

  constructor(private httpClient: HttpClient) {}

  public getAll(): any {
    return this.httpClient.get<Person[]>(`${this.apiEndpoint}`);
  }

  public create(person: Person) {
    return this.httpClient.post<Person>(`${this.apiEndpoint}`, person)
  }

  public get(id: number): any {
    return this.httpClient.get(`${this.apiEndpoint}/${id}`);
  }

  public update(person: Person) {
    return this.httpClient.put(`${this.apiEndpoint}/${person.id}`, person)
  }

  public delete(person: Person) {
    return this.httpClient.delete(`${this.apiEndpoint}/${person.id}`)
  }
}
