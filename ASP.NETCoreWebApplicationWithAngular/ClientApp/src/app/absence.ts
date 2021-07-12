import {AbsenceType} from "./absence-type.enum";
import {ApplicationUser} from "./application-user";

export interface Absence {
  id: number,
  absenceType: AbsenceType,
  applicationUserId: string;
  applicationUser: ApplicationUser;
  start: Date,
  end: Date,
  discriminator: string
}
