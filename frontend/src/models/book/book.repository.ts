import { AxiosInstance, AxiosResponse } from 'axios'

import { bookServiceKeys } from '~models/book/book.config'
import {
	IBook,
	ICreateBook,
	ITopicBooks,
	IUpdateBook,
	UseBooks,
} from '~models/book/book.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'
import { prepareRequestParams } from '~packages/utils'

export class BuildBookRepository extends CrudRepository<
	IBook[],
	IBook,
	ICreateBook,
	IUpdateBook,
	UseBooks
> {
	constructor(
		readonly http: AxiosInstance,
		readonly URL: string,
	) {
		super(http, URL)
	}

	async getByTopic(params?: Partial<UseBooks>) {
		return await this.instance.get<ResultResponse<ITopicBooks[]>>(
			`${bookServiceKeys.booksByTopic}`,
			{
				params: prepareRequestParams(params),
			},
		)
	}
}

export const BookRepository = new BuildBookRepository(
	http.instance,
	bookServiceKeys.books,
)
