export interface IPolicy {
    code: string;
    name: string;
    policyType: string;
    policyNumber: string;
    dateStart: Date;
    dateEnd: Date;
    comments: string;
    boxId: number;
    box: any;
}
