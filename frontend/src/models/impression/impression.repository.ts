import { AxiosInstance } from 'axios'

import { impressionServiceKeys } from '~models/impression/impression.config'
import {
	ICreateImpression,
	IImpression,
	IImpressionUser,
	IUpdateImpression,
	UseImpressions,
} from '~models/impression/impression.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'

export class BuildImpressionRepository extends CrudRepository<
	IImpression[],
	IImpression,
	ICreateImpression,
	IUpdateImpression,
	UseImpressions
> {
	constructor(
		readonly http: AxiosInstance,
		readonly URL: string,
	) {
		super(http, URL)
	}

	async getByUser(userId: string, params?: Partial<UseImpressions>) {
		return await this.instance.get<ResultResponse<IImpressionUser[]>>(
			`${impressionServiceKeys.impressionsByUser}/${userId}`,
		)
	}

	async getByBook(bookId: string, params?: Partial<UseImpressions>) {
		return await this.instance.get<ResultResponse<IImpression[]>>(
			`${impressionServiceKeys.impressionsByBook}/${bookId}`,
		)
	}
}

export const ImpressionRepository = new BuildImpressionRepository(
	http.instance,
	impressionServiceKeys.impression,
)
