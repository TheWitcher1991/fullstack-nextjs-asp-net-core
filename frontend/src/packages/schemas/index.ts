import { z } from 'zod'

import { regexPatterns } from '~packages/regex'
import { BOOK_FILE_TYPES, IMAGE_FILE_TYPES } from '~packages/system'

export const buildFileShape = (
	fileUploads: string[],
	video_upload_size_md: number = 10,
) => {
	return z
		.instanceof(File)
		.refine(file => fileUploads.includes(file.type), {
			message: `Неверный тип файла, разрешено: ${fileUploads.join(', ')}`,
		})
		.refine(file => file.size > video_upload_size_md * 8 * 1024, {
			message: `Размер файла не должен превышать ${video_upload_size_md} MB`,
		})
}

const inRange = (x: number, y: number) => (n: number) => n >= x && n <= y

export const zShape = {
	range: (x, y) => {
		return z.number().refine(inRange(x, y), {
			message: `Значение должно быть в диапазоне ${x}-${y}`,
		})
	},
	id: z.string().uuid(),
	string: z.string().max(255),
	decimal: z.number().positive(),
	image: buildFileShape(IMAGE_FILE_TYPES, 5),
	file: buildFileShape(BOOK_FILE_TYPES, 50),
	ids: z.number().positive().array(),
	uuids: z.string().uuid().array(),
	uuid: z.string().uuid(),
	datetime: z.string().datetime(),
	url: z.string().url(),
	title: z.string().min(3).max(255),
	text: z.string().min(3).max(3000),
	email: z.string().email().min(2).max(50),
	name: z.string().min(3).max(50),
	password: z.string().min(8).max(255),
	phone: z
		.string()
		.regex(
			regexPatterns.russianPhone.value,
			regexPatterns.russianPhone.message,
		),
}

export const FileMetaSchema = z.object({
	url: z.string().url(),
	name: z.string().min(3).max(255),
})
