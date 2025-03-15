import { format } from 'date-fns'

export const calcPercent = (a: number, b: number) => {
	return Math.round((a * 100) / (b || 1))
}

export const formatDateInRu = (date: string): string => {
	return format(new Date(date), 'dd.MM.yyyy')
}

export function spaced(val: number): string {
	if (val < 10000) {
		return val.toString()
	}

	return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ' ')
}

export function trimText(text?: Nullable<string>, length?: number) {
	if (!text || !length || text.length <= length) {
		return text
	}

	return `${text.substring(0, length)}...`
}

export const prepareRequestParams = <T extends Record<string, any>>(
	params?: T,
): Record<string, any> => {
	if (!params) return undefined

	return params
		? Object.fromEntries(
			Object.entries(params).map(([key, value]) =>
				Array.isArray(value)
					? [key, value.join(',')]
					: [key, value],
			),
		)
		: {}
}

export const isValidFileType = (file: File, types: string[]): boolean => {
	return types.includes(<string>file?.type)
}

export const isValidFileSize = (file: File, size_bytes: number): boolean => {
	return file.size <= size_bytes
}

export function image64ToImage(base64: string) {
	return new Promise((resolve, reject) => {
		const img = new Image()
		img.src = base64
		img.onload = () => {
			resolve(img)
		}
		img.onerror = () => {
			reject(img)
		}
	})
}

export function cropImage(
	image,
	x: number,
	y: number,
	newWidth: number,
	newHeight: number,
) {
	const canvas = document.createElement('canvas')
	canvas.width = newWidth
	canvas.height = newHeight
	const ctx = canvas.getContext('2d')

	if (!ctx) return undefined

	ctx.drawImage(image, x, y, newWidth, newHeight, 0, 0, newWidth, newHeight)
	return canvas.toDataURL('image/jpeg')
}

export async function cropImage64(
	base64: string,
	x: number,
	y: number,
	newWidth: number,
	newHeight: number,
) {
	const img = await image64ToImage(base64)
	return cropImage(img, x, y, newWidth, newHeight)
}

export const getRandomFileName = () => {
	return Math.random().toString(36).substring(2, 15)
}

export async function imageSrcToFile(
	imageSrc,
	fileName = getRandomFileName(),
	mimeType = 'image/png',
): Promise<File> {
	if (imageSrc.startsWith('data:')) {
		const base64Response = await fetch(imageSrc)
		const blob = await base64Response.blob()
		return new File([blob], fileName, { type: mimeType })
	} else {
		const response = await fetch(imageSrc)
		const blob = await response.blob()
		return new File([blob], fileName, { type: blob.type })
	}
}

export const fileToBase64 = (
	file: Nullable<File>,
	callback: (data: string) => void,
) => {
	if (!file) {
		return
	}

	const reader = new FileReader()
	reader.onload = () => {
		return callback(reader.result as string)
	}
	reader.readAsDataURL(file)
}
