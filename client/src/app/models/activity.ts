export interface Activity {
  id: number;
  name: string;
  details: string;
  place: string | null;
  scheduledDateTime: string | null;
  ticketPrice: number | null;
  capacity: number | null;
  available: number | null;
  imageUrl: string | null;
  createdDateTime: string;
}
