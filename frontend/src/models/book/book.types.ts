import { z } from 'zod'

import {
	BookSchema,
	CreateBookSchema,
	UpdateBookSchema,
} from '~models/book/book.schema'

export type IBook = z.infer<typeof BookSchema>

export type ICreateBook = z.infer<typeof CreateBookSchema>

export type IUpdateBook = z.infer<typeof UpdateBookSchema>

export type ITopicBooks = {
	topicId: string
	topicTitle: string
	books: IBook[]
}

export type UseBooks = UseModelOptions & {
	category: string
	topic: string
}
