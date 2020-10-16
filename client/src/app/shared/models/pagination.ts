import { IMedicine } from './medicine';

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IMedicine[];
}